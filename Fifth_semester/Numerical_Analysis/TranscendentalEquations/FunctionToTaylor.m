function [ xs ] = FunctionToTaylor( func, x0 )
    f = symfun(sym(func), sym('x'));
    df = diff(func, sym('x'));
    d2f = diff(df, sym('x'));
    condition = true;
    xs(1) = x0;
    k = 2;
    epsilon = 1 / 10^5;
    while condition
        dy = sym('y') - f(xs(k - 1));
        f = f(xs(k - 1)) + df(xs(k - 1)) * (x - xs(k - 1))
        
        F = symfun(F, sym('y'));
        xs(k) = eval(F(0));
        condition = (abs(xs(k) - xs(k - 1)) > epsilon);
        k = k + 1;
    end

end