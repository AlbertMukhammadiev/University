function [ S ] = GaussLegendreQuadrature( a, b, n )
    n = 5;
    S = 0;
    xs = GetLegendreRoots();
    for i = 1 : n
        dPnx = dLegendrePolinomial(xs(i), n);
        w = 2 / (1 - xs(i) ^ 2) / dPnx ^ 2;
        x = ((b - a) / 2 * xs(i) + (a + b) / 2);
        S = S + w * f(x);
    end
    S = (b - a) / 2 * S;
end

