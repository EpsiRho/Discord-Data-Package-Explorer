using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDataPackageLoader.Classes
{
    public static class DataPackageManager
    {
        // Progress
        public static int ProgressValue { get; set; }
        public static int ProgressTotal { get; set; }
        public static bool IsActive { get; set; }

        // Account folder
        public static Account? UserAccount;
        public static string? ImagePath;

        // Activity
        public static List<DiscordEvent> Events;

        // Messages
        public static Dictionary<string, string> MessagesIndex { get; set; }
        public static Dictionary<Channel, List<Message>> Messages { get; set; }

        // Servers
        public static List<Guild> Guilds;

        public static void LoadGuilds(object FolderPath)
        {
            IsActive = true;
            ProgressValue = 0;
            var folders = Directory.GetDirectories($"{FolderPath}\\servers");
            ProgressTotal = folders.Length;
            Guilds = new List<Guild>();
            foreach(var folder in folders)
            {
                string json = File.ReadAllText($"{folder}\\guild.json");
                var guild = JsonConvert.DeserializeObject<Guild>(json);
                Guilds.Add(guild);
                ProgressValue++;
            }
            IsActive = false;
        }


        public static void LoadMessages(object FolderPath)
        {
            IsActive = true;
            ProgressValue = 0;
            ProgressTotal = 100;
            MessagesIndex = new Dictionary<string, string>();
            Messages = new Dictionary<Channel, List<Message>>();
            StreamReader sr = File.OpenText($"{FolderPath}\\messages\\index.json");

            JsonTextReader reader = new JsonTextReader(sr);

            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    reader.Read();
                    reader.Read();
                    while (true)
                    {
                        string id = reader.Value.ToString();
                        reader.Read();
                        string value = "???";
                        try
                        {
                            value = reader.Value.ToString();
                        }
                        catch
                        {

                        }
                        reader.Read();
                        MessagesIndex.Add(id, value);


                        if (reader.TokenType == JsonToken.EndObject)
                        {
                            break;
                        }
                    }
                }
            }
            sr.Close();
            sr.Dispose();


            var folders = Directory.GetDirectories($"{FolderPath}\\messages");
            ProgressTotal = folders.Count();
            foreach(var folder in folders)
            {
                string json = File.ReadAllText($"{folder}\\channel.json");
                var channel = JsonConvert.DeserializeObject<Channel>(json);
                foreach(var idx in MessagesIndex)
                {
                    if(channel.id == idx.Key)
                    {
                        channel.name = idx.Value.Replace("Direct Message with ", "");
                    }    
                }
                List<Message> messages = new List<Message>();
                string msgs = File.ReadAllText($"{folder}\\messages.csv").Replace("\r","").Split("Attachments")[1];
                List<string> lines = new List<string>(msgs.Substring(1).Split('\n'));
                int i = 0;
                while(i < lines.Count)
                {
                    if(lines[i].Contains(",\""))
                    {
                        if(lines[i].Contains("\","))
                        {
                            int start = lines[i].IndexOf('\"');
                            int last = lines[i].LastIndexOf('\"');
                            string content = lines[i].Substring(start, last-start);
                            string[] split = lines[i].Split(",");
                            try
                            {
                                messages.Add(new Message() { Id = Convert.ToUInt64(split[0].Replace("\n", "")), Timestamp = DateTime.Parse(split[1]), Contents = content, Attachments = split[3] });
                                i++;
                            }
                            catch(Exception)
                            {
                                i++;
                            }
                        }
                        else
                        {
                            string content = lines[i].Substring(lines[i].IndexOf('\"'));
                            string attachments = "";
                            int c = 1;
                            while (true)
                            {
                                content += $"\n{lines[i + c]}";
                                if (lines[i + c].Contains("\","))
                                {
                                    attachments = lines[i + c].Substring(lines[i+c].IndexOf("\","));
                                    break;
                                }
                                c++;
                            }
                            string[] split = lines[i].Split(",");
                            messages.Add(new Message() { Id = Convert.ToUInt64(split[0].Replace("\n", "")), Timestamp = DateTime.Parse(split[1]), Contents = content, Attachments = attachments });
                            i += c;
                        }
                    }
                    else
                    {
                        string[] split = lines[i].Split(",");
                        if(split.Length != 4)
                        {
                            i++;
                            continue;
                        }
                        try
                        {
                            messages.Add(new Message() { Id = Convert.ToUInt64(split[0].Replace("\n", "")), Timestamp = DateTime.Parse(split[1]), Contents = split[2], Attachments = split[3] });
                        }
                        catch (Exception)
                        {

                        }
                        i++;
                    }
                }

                //string[] split = msgs.Split("Attachments")[1].Split(',');
                //for(int i = 0; i < split.Length - 1; i+=0)
                //{
                //    try
                //    {
                //        messages.Add(new Message() { Id = Convert.ToUInt64(split[i].Replace("\n", "")), Timestamp = DateTime.Parse(split[i + 1]), Contents = split[i + 2], Attachments = split[i + 3] });
                //        i += 3;
                //    }
                //    catch(Exception)
                //    {
                //        i++;
                //    }
                //}
                Messages.Add(channel, messages);
                ProgressValue++;

            }

            IsActive = false;
        }

        public static void LoadAccount(object FolderPath)
        {
            IsActive = true;
            ProgressValue = 0;
            ProgressTotal = 100;
            string json = File.ReadAllText($"{FolderPath}\\account\\user.json");
            ProgressValue = 50;
            UserAccount = JsonConvert.DeserializeObject<Account>(json);
            ProgressValue = 90;
            ImagePath = $"{FolderPath}\\account\\avatar.png";
            ProgressValue = 100;
            IsActive = false;
        }

        public static void LoadEvents(object FolderPath)
        {
            IsActive = true;
            Events = new List<DiscordEvent>();
            var folders = Directory.GetDirectories($"{FolderPath}\\activity");
            ProgressValue = 0;
            ProgressTotal = 0;
            List<string> AllLines = new List<string>();
            foreach (var folder in folders)
            {
                var files = Directory.GetFiles(folder);
                foreach (var file in files)
                {
                    var lines = File.ReadAllLines(file);
                    AllLines.AddRange(lines);
                    ProgressTotal += lines.Count();
                }
            }
            foreach (var line in AllLines)
            {
                try
                {
                    Events.Add(JsonConvert.DeserializeObject<DiscordEvent>(line));
                }
                catch(Exception)
                {

                }
                ProgressValue++;
            }
            IsActive = false;
        }
    }
}
