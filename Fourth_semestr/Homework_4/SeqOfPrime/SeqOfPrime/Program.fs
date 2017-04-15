module Program

let primes =
    let mutable finded = [2; 3]
    let mutable prevPrime = 3
    let get n = 
        let rec checkPrime k =
            if List.forall (fun x -> k % x <> 0) finded then
                finded <- List.append finded [k]
                prevPrime <- k
                k
            else
                checkPrime (k + 1)
        
        match n with
        | x when x > 1 -> checkPrime (prevPrime + 2)
        | x when x = 1 -> 3
        | _ -> 2
            
    Seq.initInfinite (fun n -> get n)    
