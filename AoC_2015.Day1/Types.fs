namespace AoC_2015.Day1

[<Struct>]
type Floor = Floor of int64

[<Struct>]
type Direction =
    | UpOne
    | DownOne
    
type Directions = Directions of Direction list
    
module Floor =
    let move floor direction =
        match floor, direction with
        | Floor floor, UpOne -> floor + 1L |> Floor
        | Floor floor, DownOne -> floor - 1L |> Floor
        
    let fold initialFloor directions =
        List.fold move initialFloor directions
        
    let findBasement initialFloor directions =
        List.scan move initialFloor directions
        |> List.takeWhile (fun (Floor f) -> f >= 0)
        |> List.length