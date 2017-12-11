function [ ] = Task2( )
    n = 20;
    xs = 1 : 1 : 20;
    a = -1;
    b = 1;
    
    intf = 20;
    for k = 1 : n
        Sums(k) = MehlerQuadrature(k);
        actualErrors(k) = Sums(k) - Sums(k);
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        ksi = 1;
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        theorErrors(k) = pi / factorial(2 * k) / 2^(2 * k - 1) * df(ksi, 2 * k);
    end
    
    f = figure;
    title('Mehler Quadrature');
    hold on;
    grid on;
    actErrPlot = semilogy(xs, actualErrors, 'DisplayName', 'Actual errors');
    theorErrPlot = semilogy(xs, theorErrors, 'DisplayName', 'Theoretical errors');
    set(actErrPlot, 'LineWidth', 1.5);
    set(theorErrPlot, 'LineWidth', 1.5);
    legend('show');
    %print(f, '-dpng', '-r300', someRule);
end

