open Variations
open System

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

//PRESENTATION
let showWonderSetup codes playerCount =
    let wonders = getWondersByCode codes
    printfn "\t%s (you)" (wonders[0])
    printf "%s" (wonders[(playerCount - 1)])
    printfn "\t\t%s" (wonders[1])
    for i in [2..(playerCount - 2)] |> List.rev do
        printf "\t%s\t" (wonders[i])

    printfn ""

//UTILS
let debug a =
    printfn "%A" a
    a

//SAVING AND READING
let generateLogEntry playerCount code place  =
    let c =
        code
        |> Seq.ofList
        |> Seq.map string
        |> String.Concat
    $"{playerCount}P;{c};{place}"

type LogEntry = {
    playerCount: int;
    code: int list;
    place: int
}

let charToInt c =
    int c - int '0'

let parseLogEntry (s:string) =
    let f = s.Split(";")
    let c = f[1] |> List.ofSeq |> List.map charToInt
    let pc = f[0][0]
    {playerCount=charToInt pc; code=c; place=int f[2]}

// ANALYZING

let calculateWonderPlace entryLogs wonder =
    let total =
        entryLogs
        |> List.filter (fun e -> e.code[0] = wonder)
        |>List.sumBy (fun e -> e.place)
    float total / float entryLogs.Length

///TESTING
let wonders = [1..7]
let playerCount = 3
let wonderCodes = generateWonderCodes wonders playerCount

printfn "%d" (List.length wonderCodes)
for i in 1..2 do
    showWonderSetup wonderCodes[i] playerCount

for i in 3..7 do
    let wc = generateWonderCodes wonders i
    printfn "%d\t%d\n" (i) (List.length wc)

printfn "%A" (parseLogEntry "3P;123;1")
printfn "%A" (parseLogEntry "4P;1234;1")
printfn "%A" (generateLogEntry 3 [1;2;3] 1)
printfn "%A" (generateLogEntry 4 [1;2;4] 2)

let LogEntries = [parseLogEntry "3P;123;1"; parseLogEntry "3P;123;1"; parseLogEntry "3P;123;2"]
let avg = calculateWonderPlace LogEntries 1
printfn "%0.2f" (avg)