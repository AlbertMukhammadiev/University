% Draws graph of errors
function [ ] = DrawGraph( func, n, step )
    T = pi;
    a = 0;
    b = a + T;
    
    % search of max derivative^(2)
    d2f = simplify(diff(sym(func), sym('x'), 2));
    fplot(d2f, [a , b]);
    max_d2f = sym(max(max(ylim), abs(min(ylim))));
    
    for k = 1 : n
        errors = GetErrors(func, max_d2f, a, b, k, T);
        periodic(k) = errors(1);
        theoretical(k) = errors(2);
        actual(k) = errors(3);
        Runge(k) = errors(4);
    end
    
    f = figure;
    lineWidth = 1.5;
    start = 1 + step;
    xs = start : 1 : n;
    semilogy(xs, actual(start : n),...
        'DisplayName','Actual errors',...
        'LineWidth', lineWidth);
    hold on;
    semilogy(xs, theoretical(start : n),...
        'DisplayName', 'Theoretical errors',...
        'LineWidth', lineWidth);
    semilogy(xs, Runge(start : n),...
        'DisplayName', 'Runge',...
        'LineWidth', lineWidth);
    semilogy(xs, periodic(start : n),...
        'DisplayName', 'Theoretical(periodic) errors',...
        'LineWidth', lineWidth);
    legend('show');
    title('Riemann Sum');
    grid on;
    hold off;
    print(f, '-dpng', '-r300', 'RiemannSum1');
end

