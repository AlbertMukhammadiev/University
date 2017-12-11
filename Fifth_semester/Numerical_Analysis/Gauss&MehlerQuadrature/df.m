% computes the nth derivative at the point x
function [ result ] = df( x, n )
    if n < 0
        n = 0;
    end

    deg = - 1 / 2;
    result = f(x);
    for k = 1 : n
        result = deg * result / (1 + x);
        deg = deg - 1;
    end
end