using System;

namespace HelloWorld
{
  public class MessageEncoder
  {
      
      public string encodeMessage(string message)
      {
          if(message.Length <= 4)
            return $"The string {message} has minimum Length";
          
          if(message.Contains(" "))
            return $"The string {message} Contains space";
          
          string newMessage = "";
          int newChar;
          foreach(var item in message){
            newChar = (int)item - 10;
            newMessage += (char)newChar;
          }
          
          return newMessage;
      }
  }
  
  public class UserInterface{
    
   public static void Main(string[] args){
      string message = "HelloWorld";
      MessageEncoder msg = new MessageEncoder();
      
      string result = msg.encodeMessage(message);
      
      Console.WriteLine(result);
   }
  }
}