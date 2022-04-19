open WonderAnalyzer
open Utils


let getAverageResultsFromLogs playerCount path =
    path
    |> readLines
    |> Seq.map parseLogEntry
    |> List.ofSeq
    |> getWondersStats
    |> List.iter (fun (i, place) -> printfn "%s: %0.2f" (getWonderByCode i) place)

getAverageResultsFromLogs 3 "testMatchups.txt"