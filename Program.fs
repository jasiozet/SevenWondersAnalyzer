open WonderAnalyzer

///TESTING
let wonders = [1..7]
let playerCount = 3
let wonderCodes = generateWonderCodes wonders playerCount

printfn "%d" (List.length wonderCodes)
for i in 1..2 do
    showWonderSetupToConsole wonderCodes[i] playerCount

for i in 3..7 do
    let wc = generateWonderCodes wonders i
    printfn "%d\t%d\n" (i) (List.length wc)

printfn "%A" (parseLogEntry "3P;123;1")
printfn "%A" (parseLogEntry "4P;1234;1")
printfn "%A" (generateLogForFile 3 [1;2;3] 1)
printfn "%A" (generateLogForFile 4 [1;2;4] 2)

let LogEntries = [parseLogEntry "3P;123;1"; parseLogEntry "3P;123;1"; parseLogEntry "3P;123;2"]
let avg = calculateWonderAveragePlace LogEntries 1
printfn "%0.2f" (avg)