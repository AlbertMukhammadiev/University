function [ xs ] = NewtonMethod( func, x0, n)
    format long;
    f = symfun(sym(func), sym('x'));
    fctr = factor(f);
    roots = solve(fctr);
    df = symfun(diff(func, sym('x')), sym('x'));
    xs(1) = eval(x0 - f(x0) / df(x0));
    
    for i = 2 : n
        x = xs(i - 1);
        xs(i) = eval(x - f(x) / df(x));
    end
end