let fibonacci n =
    let rec calcFibonacci i n acc1 acc2 =
        if i = n then
            acc1 + acc2
        else
            calcFibonacci
                (i + 1)
                (n)
                (acc2)
                (acc1 + acc2)
    if n >= 0  then
        calcFibonacci 0 n -1 1
    else
        if ((-1 * n + 1) % 2 = 0) then
            calcFibonacci 0 -n -1 1
        else
            -1 * calcFibonacci 0 -n -1 1   

[<EntryPoint>]
let main argv = 
    0 // возвращение целочисленного кода выхода
