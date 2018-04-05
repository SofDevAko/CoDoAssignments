
using System.Collections.Generic;
using weddingPlanner.Models;

public class Guest : BaseEntity
{
    public int GuestId {get;set;}
    public int UserId {get;set;}
    public User User {get;set;}
    
    public int WedId {get;set;}
    public Wedding Wedding {get;set;}
}   
