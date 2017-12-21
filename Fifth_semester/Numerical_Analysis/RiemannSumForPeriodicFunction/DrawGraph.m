% Draws graph of errors
function [ ] = DrawGraph( func )
    T = pi;
    a = 0;
    b = a + T;
    n = 10;
    xs = 2 : 1 : n;
    
    for k = 1 : n - 1
        errors = GetErrors(func, a, k + 1, T);
        periodic(k) = errors(1);
        theoretical(k) = errors(2);
        actual(k) = errors(3);
        Runge(k) = errors(4);
    end
    
    f = figure;
    title('Riemann Sum');
    hold on;
    grid on;
    actualPlot = semilogy(xs, actual, 'DisplayName', 'Actual errors');
    theorPlot = semilogy(xs, theoretical, 'DisplayName', 'Theoretical errors');
    RungePlot = semilogy(xs, Runge, 'DisplayName', 'Runge');
    periodicPlot = semilogy(xs, periodic, 'DisplayName', 'Theoretical(periodic) errors');
    set(actualPlot, 'LineWidth', 1.5);
    set(theorPlot, 'LineWidth', 1.5);
    set(RungePlot, 'LineWidth', 1.5);
    set(periodicPlot, 'LineWidth', 1.5);
    legend('show');
    print(f, '-dpng', '-r300', 'RiemannSum');
end

