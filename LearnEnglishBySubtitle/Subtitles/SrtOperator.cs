﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LearnEnglishBySubtitle.Helpers;

namespace Studyzy.LearnEnglishBySubtitle.Subtitles
{
    public class SrtOperator : ISubtitleOperator
    {
        public Subtitle Parse(string str)
        {
            var result = new List<SubtitleLine>();
            var blocks = str.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var block in blocks)
            {
                var array = block.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                var srt = new SubtitleLine();
                var num = array[0];
                srt.Number = Convert.ToInt32(num);

                var tarray = array[1].Split(new string[] { " --> " }, StringSplitOptions.RemoveEmptyEntries);
                srt.StartTime = Convert.ToDateTime("2000-01-01 " + tarray[0].Replace(',', '.'));
                srt.EndTime = Convert.ToDateTime("2000-01-01 " + tarray[1].Replace(',', '.'));

                
                srt.Text = "";
                for (var i = 2; i < array.Length;i++ )
                    srt.Text += array[i]+"\r\n";
                srt.Text= srt.Text.Remove(srt.Text.Length - 2, 2);
                result.Add(srt);
            }
            Subtitle st = new Subtitle(){Bodies=result};
            return st;
        }
        public  string Subtitle2String(Subtitle st )
        {
            StringBuilder sb=new StringBuilder();
            var srts = st.Bodies;
            foreach (var SubtitleLine in srts)
            {
                sb.Append(SubtitleLine.Number);
                sb.Append("\r\n");
                sb.Append(SubtitleLine.StartTime.ToString("HH:mm:ss,fff") + " --> " + SubtitleLine.EndTime.ToString("HH:mm:ss,fff"));
                sb.Append("\r\n");
                sb.Append(SubtitleLine.Text);
                sb.Append("\r\n\r\n");
            }
            var result = sb.ToString();
            return result.Remove(result.Length - 4);
        }

        public Subtitle RemoveChinese(Subtitle subtitle)
        {
            var newSrts = new List<SubtitleLine>();
            var srts = subtitle.Bodies;
            for (int i = 0; i < subtitle.Bodies.Count; i++)
            {
                var SubtitleLine = srts[i];
                var lines = SubtitleLine.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                IList<string> newLines = new List<string>();
                foreach (var line in lines)
                {
                    var l = StringHelper.RemoveRemark(line);
                    if (!StringHelper.IsChinese(l))
                    {
                        newLines.Add(l);
                    }
                }
                if (newLines.Count > 0)
                {
                    SubtitleLine.EnglishText = string.Join("\r\n", newLines.ToArray());
                }
                else
                {
                    SubtitleLine.EnglishText = " ";
                }
                newSrts.Add(SubtitleLine);
            }
            subtitle.Bodies= newSrts;
            return subtitle;
        }
    }

   
}
