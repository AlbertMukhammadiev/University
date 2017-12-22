function [ xs ] = ChordMethod( func, a, b, n )
    f = symfun(sym(func), sym('x'));
    fa = eval(f(a));
    fb = eval(f(b));
    if (fa * fb > 0)
        display('points are selected incorrectly');
        return;
    end
    
    d2f = symfun(diff(diff(func, sym('x')), sym('x')), sym('x')); 
    if (xor((fb > 0), (d2f((a + b) / 2) < 0)))
        xs(1) = a;
        for k = 1 : n
            xs(k + 1) = eval(xs(k) - f(xs(k)) * (b - xs(k)) / (fb - f(xs(k))));
        end
    else
        xs(1) = b;
        for k = 1 : n
            xs(k + 1) = eval(xs(k) - f(xs(k)) * (xs(k) - a) / (f(xs(k)) - fa));
        end
        return;
    end
end