function [ xs ] = InverseFunctionToTaylor( func, x0 )
    f = symfun(sym(func), sym('x'));
    df = diff(func, sym('x'));
    d2f = diff(df, sym('x'));
    
    % derivatives of inverse function
    dF = symfun(1 / df, sym('x'));
    d2F = symfun(- d2f / df^3, sym('x'));
    condition = true;
    k = 2;
    xs(1) = x0;
    epsilon = 1 / 10^12;
    while condition
        dy = sym('y') - f(xs(k - 1));
        F = xs(k - 1) + dy * dF(xs(k - 1)) - dy ^ 2 * d2F(xs(k - 1)) / 2;
        F = symfun(F, sym('y'));
        xs(k) = eval(F(0));
        condition = (abs(xs(k) - xs(k - 1)) > epsilon);
        k = k + 1;
    end
end