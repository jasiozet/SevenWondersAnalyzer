module WonderAnalyzer

open Variations
open System
open Utils

type LogEntry = {
    playerCount: int;
    code: int list;
    place: int
}

let generateWonderCodes wonders playerCount =
    wonders
    |> getVariationsWoRepetition playerCount
    |> List.ofSeq

let getWonderByCode = function
    | 1 -> "ALEXANDRIA"
    | 2 -> "BABYLON"
    | 3 -> "EPHESUS"
    | 4 -> "GIZA"
    | 5 -> "HALICARNASSUS"
    | 6 -> "OLYMPIA"
    | 7 -> "RHODES"
    | _   -> failwith "Unknown wonder code"

let getWondersByCode codes =
    codes
    |> List.map getWonderByCode
    |> List.ofSeq

let calculateWonderAveragePlace entryLogs wonder =
    let total =
        entryLogs
        |> List.filter (fun e -> e.code[0] = wonder)
        |>List.sumBy (fun e -> e.place)
    float total / float entryLogs.Length

let showWonderSetupToConsole codes playerCount =
    let wonders = getWondersByCode codes
    printfn "\t%s (you)" (wonders[0])
    printf "%s" (wonders[(playerCount - 1)])
    printfn "\t\t%s" (wonders[1])
    for i in [2..(playerCount - 2)] |> List.rev do
        printf "\t%s\t" (wonders[i])
    printfn ""

let generateLogForFile playerCount code place  =
    let c =
        code
        |> Seq.ofList
        |> Seq.map string
        |> String.Concat
    $"{playerCount}P;{c};{place}"

let parseLogEntry (s:string) =
    let f = s.Split(";")
    let c = f[1] |> List.ofSeq |> List.map charToInt
    let pc = f[0][0]
    {playerCount=charToInt pc; code=c; place=int f[2]}