% computes a definite integral on the interval [a b]
% using Midpoint rule(n - number of nodes)
function [ S, err ] = MidpointRule( a, b, n )
    n = n - 1;
    dx = (b - a) / n;
    xs = a : dx : b;
    S = 0;
    err = 0;
    for k = 1 : n
        delta = xs(k + 1) - xs(k);
        t = (xs(k + 1) + xs(k)) / 2;
        S = S + f(t) * delta;
        
        ksi = xs(k) + delta * 0.3;
        err = err + delta^3 * df(ksi, 2) / 24;
    end
end