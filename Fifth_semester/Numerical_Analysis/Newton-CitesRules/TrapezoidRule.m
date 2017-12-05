% computes a definite integral on the interval [a b]
% using Trapezoid rule(n - number of nodes)
function [ S, err ] = TrapezoidRule( a, b, n )    
    n = n - 1;
    dx = (b - a) / n;
    xs = a : dx : b;
    ys = f(xs);
    S = 0;
    err = 0;
    for k = 1 : n
        delta = xs(k + 1) - xs(k);
        S_trap = (ys(k + 1) + ys(k)) / 2 * delta;
        S = S + S_trap;
        
        ksi = xs(k) + delta * 0.3;
        err = err - delta^3 * df(ksi, 2) / 12;
    end
end