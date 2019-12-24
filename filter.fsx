#!/usr/bin/env fsharpi

open System
open System.IO

#r "System.Configuration"
#load "fsx/InfraLib/Misc.fs"
#load "fsx/InfraLib/Process.fs"
#load "fsx/InfraLib/Unix.fs"
open FSX.Infrastructure

let currDir = Environment.CurrentDirectory
let file = Path.Combine(currDir, "out.txt") |> FileInfo
let toFile = file.FullName.Replace("out.txt", "out2.txt") |> FileInfo
let filter (line: string): Option<string> =
    let isHexChar (c: Char) =
        (Char.IsNumber c) || c = 'A' || c = 'a'
                          || c = 'B' || c = 'b'
                          || c = 'C' || c = 'c'
                          || c = 'D' || c = 'd'
                          || c = 'E' || c = 'e'
                          || c = 'F' || c = 'f'
    let rec removeImmediateData(line: string) =
        if line.Contains "0x" then
            // remove 0x7f3d38004ea0
            let before =
                try
                    line.Substring(0, line.IndexOf("0x"))
                with
                | ex ->
                    failwithf "f1: %s<<%s" line (ex.ToString())
            let after =
                try
                    let start = line.IndexOf("0x")
                    let mutable endd = 2
                    while (start+endd<line.Length && isHexChar line.[start+endd]) do
                        endd <- endd + 1
                    line.Substring(start+endd)
                with
                | ex ->
                    failwithf "f2: '%s' from '%s'<<%s" before line (ex.ToString())
            sprintf "%s%s%s" before "HEX" after |> removeImmediateData
        else
            line

    let removedData = removeImmediateData line
    if removedData.Contains "] " then
        removedData.Substring(removedData.IndexOf("] ") + 2) |> Some
    else
        Some removedData

Misc.ApplyLineChangesOverTextFile file toFile filter
