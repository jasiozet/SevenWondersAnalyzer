module Variations
/// Rotates a list by one place forward.
let rotate lst =
    List.tail lst @ [List.head lst]

/// Gets all rotations of a list.
let getRotations lst =
    let rec getAll lst i = if i = 0 then [] else lst :: (getAll (rotate lst) (i - 1))
    getAll lst (List.length lst)

let getVariationsWoRepetition n lst =
    let rec getPermsImpl acc n lst = seq {
        match n, lst with
        | k, x :: xs ->
            if k > 0 then
                for r in getRotations lst do
                    yield! getPermsImpl (List.head r :: acc) (k - 1) (List.tail r)
            if k >= 0 then yield! getPermsImpl acc k []
        | 0, [] -> yield acc
        | _, [] -> ()
        }
    getPermsImpl List.empty n lst