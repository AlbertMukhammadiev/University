function [ xs ] = InverseQuadraticInterpolation( func, x1, x2, x3 )
    xs(1) = x1;
    xs(2) = x2;
    xs(3) = x3;
    f = symfun(sym(func), sym('x'));
    k = 3;
    epsilon = 1 / 10^5;

    while (abs(xs(k) - xs(k - 1)) > epsilon)
        ys = eval(f(xs(k - 2 : k)));
        Q2 = LagrangePolynomial(ys, xs(k - 2 : k));
        funcQ = symfun(sym(Q2), sym('x'));
        xs(k + 1) = funcQ(0);
        k = k + 1;
    end
    
end

