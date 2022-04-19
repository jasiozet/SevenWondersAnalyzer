module Utils
open System.IO

let debug a =
    printfn "%A" a
    a

let charToInt (c:char) =
    int c - int '0'

let readLines (filePath:string) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

let writeAnalyzerResult (filePath:string) (lines : string list =
    File.WriteAllLines filePath lst