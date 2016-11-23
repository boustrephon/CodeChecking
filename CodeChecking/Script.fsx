// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Component1.fs"
open CodeChecking
open CodeChecking.HKConc

// tests
printfn "%A" ConcStress
printfn "e_cu: %0.3f" (e_cu 70.0)
printfn "e_d: %0.0f" (e_d 70.0)
printfn "e_c0: %0.4f" (e_c0 70.0)
printfn "Max stress: %0.3f" (f_max 70.0)

printfn ""
let res strain f_cu = 
    printfn "ConcStress (f_cu=%0.1f, strain=%0.4f) is %0.3f" f_cu strain (ConcStress strain f_cu)
res -0.0002 70.0
res 0.00 70.0
res 0.0004 70.0
res 0.002 70.0
res 0.0025 70.0
res 0.0036 70.0

let strainlist = [0.001;0.002;0.003;0.004]
let strainseq = seq{0.0 .. 0.1 .. 4.0}
let strainarray = [| for i in 0 .. 40 -> 0.0001 * float(i) |]

let list2 = [0.2 .. 0.5]. // fails


List.iter (fun x -> printfn "%f" x ) strainlist
printfn " "
List.map (fun x -> ConcStress (0.001 * x) 70.0) strainlist |> List.iter (printfn "%f" )
printfn "\n--- strainseq ---"
strainseq 
    |> Seq.map (fun x -> ConcStress (0.001 * x) 70.0)  
    |> Seq.zip strainseq 
    |> Seq.iter (fun x -> printfn "%f\t%f" (0.001 * (fst x)) (snd x) )
// could also use Seq.iter2 in place of zip & iter
// NB seq is slower than array

printfn "\n--- strainseq (2) ---"
strainseq 
    |> Seq.map (fun x -> ConcStress (0.001 * x) 70.0)  
    |> Seq.iter2 (fun x y-> printfn "%f\t%f" (0.001 * x) y ) strainseq 


printfn "\n--- strainarray --- "
strainarray 
    |> Array.map (fun x -> ConcStress x 70.0)  
    |> Array.iter2 (fun x y -> printfn "%f\t%f" x y ) strainarray

let list4 = seq { 0.001 .. 0.001 .. 0.007 }

let list3 = seq { for i in 1 .. 2 .. 7 -> i * i }

let list5 = seq { for i in 1 .. 7 -> 0.001 * float(i) }
