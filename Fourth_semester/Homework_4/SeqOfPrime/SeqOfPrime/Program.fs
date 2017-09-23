module Program

let primes =
    let isPrime x =
        let squareRoot = int << sqrt << float <| x
        let rec check k =
            (x % k <> 0 && check (k + 1)) || k > squareRoot
        check 2

    let get n =
        let rec getTR (k:int) n =
            if (isPrime k) then
                if n = 0 then
                    k
                else
                    getTR (k + 1) (n - 1)
            else
                getTR (k + 1) n
        getTR 2 n

    Seq.initInfinite (fun n -> get n)