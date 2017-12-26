% Draws graph of errors
function [ ] = DrawGraph( func, n, step )
    T = pi;
    a = 0;
    b = a + T;
    
    % search of max derivative^(2)
    d2f = simplify(symfun(diff(diff(func, sym('x'))), sym('x')) );
    x = a;
    b = a + T;
    dx = 1 / 100;
    max_d2f = -inf;
    while x < b
        temp = abs((d2f(x)));
        if temp > max_d2f
            max_d2f = temp;
        end
        x = x + dx;
    end
    max_d2f = vpa(max_d2f);
    
    for k = 1 : n
        errors = GetErrors(func, max_d2f, a, b, k, T);
        periodic(k) = errors(1);
        theoretical(k) = errors(2);
        actual(k) = errors(3);
        Runge(k) = errors(4);
    end
    
    f = figure;
    title('Riemann Sum');
    hold on;
    grid on;
    lineWidth = 1.5;
    start = 1 + step;
    xs = start : 1 : n;
    semilogy(xs, actual(start : n),...
        'DisplayName','Actual errors',...
        'LineWidth', lineWidth);
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
    print(f, '-dpng', '-r300', 'RiemannSum1');
end

