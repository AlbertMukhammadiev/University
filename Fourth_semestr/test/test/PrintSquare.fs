module PrintSquare

//    let rec printTR n list =
//        let length = List.length list
//        match n with
//        | length -> List.iter (fun x -> printfn "%c" x) list
//                    printTR (n - 1) (list)
//
//        |  -> printfn "%c" '*'
//               Seq.iter (fun x -> printfn "%c" x) <| Seq.take (length - 2) list
//               printfn "%c" '*'
//               printTR (n - 1) (list)

//    let rec create list n acc =
//        if acc = n then list
//        else
//            create ('*' :: list) n (acc + 1)

let print n =
    let seq n = Seq.init n (fun x -> '*')

    let rec printTR n seq =
        let length = Seq.length seq
        if length = n then
            Seq.iter (fun x -> printf "%c" x) seq
            printfn ""
            printTR (n - 1) (seq)
        else if n = 1 then
            Seq.iter (fun x -> printf "%c" x) seq
            printfn ""
        else
            printf "%c" '*'
            Seq.iter (fun x -> printf "%c" ' ') <| Seq.take (length - 2) seq
            printfn "%c" '*'
            printTR (n - 1) (seq)      

    let stars = seq n
    printTR n stars 