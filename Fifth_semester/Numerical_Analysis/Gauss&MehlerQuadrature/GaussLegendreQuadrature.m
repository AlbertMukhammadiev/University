% returns approximation of integral using Gauss quadrature
function [ S ] = GaussLegendreQuadrature( a, b, n )
    if n > 5
        n = 5;
    end
    if n < 1
        n = 1;
    end

    S = 0;
    format long;
    xs = GetLegendreRoots(n);
    for i = 1 : n
        dPnx = dLegendrePolinomial(xs(i), n);
        x = ((b - a) / 2 * xs(i) + (a + b) / 2);
        w = 2 / (1 - xs(i) ^ 2) / dPnx ^ 2;
        S_t = w * f(x);
        S = S + S_t;
    end
    S = (b - a) / 2 * S;
end

