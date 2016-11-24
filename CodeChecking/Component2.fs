namespace realWorld
//listing 4.2 (Real World Functional Programming)

open System

module four =
    let convertDataRow (csvLine:string) = 
        let cells = List.ofSeq(csvLine.Split(','))
        match cells with
        | title::number::_ ->
            let parsedNumber = Int32.Parse(number)
            (title,parsedNumber)
        | _ -> failwith "Incorrect data format!"

    //convertDataRow("123")
    let (a,b) = convertDataRow "Testingreading, 123"
    printfn "%s: %i" a b

// printfn "Hello World!"
