﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

[Table("Message")]
public partial class Message
{
    [Key]
    public int ID { get; set; }
    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Subject { get; set; }
    [Required]
    [Unicode(false)]
    public string MessageContent { get; set; }
}