% computes a definite integral on the interval [a b]
% using Simpson's rule(n - number of nodes)
function [ S, err ] = SimpsonsRule( a, b, n )
    n = n - 1;
    dx = (b - a) / n;
    xs = a : dx : b;
    ys = f(xs);
    S = 0;
    err = 0;
    for k = 1 : n
        midX = (xs(k) + xs(k + 1)) / 2;
        midY = f(midX);
        leftY = ys(k);
        rightY = ys(k + 1);
        delta = xs(k + 1) - xs(k);
        S_k = (leftY + 4 * midY + rightY) * delta / 6;
        S = S + S_k;
        
        ksi = xs(k) + delta * 0.3;
        err = err - delta^5 * df(ksi, 4) / 2880;
    end
end