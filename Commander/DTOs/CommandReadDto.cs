﻿using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs
{
    public class CommandReadDto
    {         
        public int Id { get; set; }

        public string HowTo { get; set; }
       
        public string Line { get; set; }

        //это поле убрал в дто
        //public string Platform { get; set; }
    }
}
