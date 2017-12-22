function [ xs ] = DirectInterpolation( func, x1, x2, x3 )
    xs(1) = x1;
    xs(2) = x2;
    xs(3) = x3;
    f = symfun(sym(func), sym('x'));
    k = 3;
    epsilon = 1 / 10^8;

    while (abs(xs(k) - xs(k - 1)) > epsilon)
        ys = eval(f(xs(k - 2 : k)));
        P2 = LagrangePolynomial(xs(k - 2 : k), ys);
        roots = solve(P2);
        xs(k + 1) = min(abs(roots));
        k = k + 1;
    end
end

