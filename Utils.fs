module Utils

let debug a =
    printfn "%A" a
    a

let charToInt (c:char) =
    int c - int '0'