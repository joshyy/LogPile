/*
 * This is free and unencumbered software released into the public domain.
 * 
 * Anyone is free to copy, modify, publish, use, compile, sell, or
 * distribute this software, either in source code form or as a compiled
 * binary, for any purpose, commercial or non-commercial, and by any
 * means.
 * 
 * In jurisdictions that recognize copyright laws, the author or authors
 * of this software dedicate any and all copyright interest in the
 * software to the public domain. We make this dedication for the benefit
 * of the public at large and to the detriment of our heirs and
 * successors. We intend this dedication to be an overt act of
 * relinquishment in perpetuity of all present and future rights to this
 * software under copyright law.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 * 
 * For more information, please refer to <http://unlicense.org>
 */
using System;
using System.IO;
using System.Reflection;


public class LogPile {		
	
	//defaults - use config file to customize	
	static string dateFormatFileNm = "yyyy-MM-dd"; //easily control file name rollover by using H, m or s in dateFormatFileNm. Default is daily.
	static string dateFormatLog = "yyyy-MM-dd HH:mm:ss:fff";
	
	static string dir = Environment.CurrentDirectory;
	static string fileNm = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
	static string fileExt = ".logpile";
	
	internal static void WriteLine(string level, string message) {
		DateTime date = DateTime.Now;
		string logFile = Path.Combine(dir, fileNm + "_" + date.ToString(dateFormatFileNm) + fileExt);
		string className = "ClassNameHere"; // todo:
		using (StreamWriter w = new StreamWriter(logFile, true)) {
			w.WriteLine(string.Format("{0}|{1}|{2}|{3}", date.ToString(dateFormatLog), level, className, message));			
		}
	}
	
	public static void Info(string message) {		
		WriteLine("INFO", message);
	}		

	public static void InfoFormat(string message, params object[] args) {		
		WriteLine("INFO", string.Format(message, args));
	}
	
	public static void Debug(string message) {		
		WriteLine("DEBUG", message);
	}	

	public static void DebugFormat(string message, params object[] args) {		
		WriteLine("DEBUG", string.Format(message, args));
	}	

	public static void Warn(string message) {		
		WriteLine("WARN", message);
	}	

	public static void WarnFormat(string message, params object[] args) {		
		WriteLine("WARN", string.Format(message, args));
	}	
	
	public static void Fatal(string message) {		
		WriteLine("FATAL", message);
	}	

	public static void FatalFormat(string message, params object[] args) {		
		WriteLine("FATAL", string.Format(message, args));
	}	
	
	public static void Error(string message) {		
		WriteLine("ERROR", message);
	}	

	public static void ErrorFormat(string message, params object[] args) {		
		WriteLine("ERROR", string.Format(message, args));
	}	
	
	public static void Custom(string level, string message) {		
		WriteLine(level, message);
	}
	
	public static void CustomFormat(string level, string message, params object[] args) {		
		WriteLine(level, string.Format(message, args));
	}
}
