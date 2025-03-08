namespace AoC_2015.Day2

[<Measure>] type ft

type Present = Present of length: uint8<ft> * width: uint8<ft> * height: uint8<ft>

module Present =
    let parsePresentData (data: string) =
        let parsePresent (s : string) =
            s.Split('x')
            |> Array.toList
            |> List.map (fun s ->
                s
                |> uint8
                |> (*) 1uy<ft>)
            |> function
                | l::w::h::_ -> (l, w, h) |> Present
               
        data.Split()
        |> Array.toList
        |> List.map parsePresent
    let getSurfaceArea presents =