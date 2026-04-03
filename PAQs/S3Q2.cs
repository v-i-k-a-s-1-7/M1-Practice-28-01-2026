using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class PlayListManager{
      
      public LinkedList<string> link = new LinkedList<string>();
      
      public int addSong(string songId){
        if(!link.Contains(songId))
            link.AddLast(songId);
        
        return 1;
      }
      
      public int removeSong(string songId){
          
          if(link.Contains(songId)){
            link.Remove(songId);
          }
          return 1;
      }
      
      public int moveToTop(string songId){
        
        removeSong(songId);
        link.AddFirst(songId);
        
        return 1;
      }
      
      public string getPlaylistOrder(){
        
        return String.Join(",", link);
      }
      
      public  int processComands(System.IO.TextReader input, int N){
        
        for(int i = 0; i< N; i++){
          string inputCommand = Console.ReadLine();
          string[] parts = inputCommand.Split(" ");
          
          string command = parts[0];
          
          if(command == "ADD"){
            addSong(parts[1]);
          }
          if(command == "REMOVE"){
            removeSong(parts[1]);
          }
          if(command == "TOP"){
            moveToTop(parts[1]);
          }
          if( command == "PRINT"){
            Console.WriteLine(getPlaylistOrder());
          }
        }
        
        return 1;
      }
    }
    
    public class Program{
      
      public static void Main(string[] args){
        
        PlayListManager music = new PlayListManager();
        int N = int.Parse(Console.ReadLine());
        
        music.processComands(Console.In, N);
      }
    }
    
      
}
