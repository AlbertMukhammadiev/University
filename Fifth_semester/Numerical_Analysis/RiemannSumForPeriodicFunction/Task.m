function [ ] = Task( func )
    T = pi;
    a = 0;
    b = T;
    n = 10;
    xs = 1 : 1 : n;

    df = diff(func, sym('x'));
    x = a;
    df_a = eval(df);
    x = b;
    df_b = eval(df);
    I = int(func, sym('x'), 0, T);
    
    for k = 1 : n
        [S(k), R(k)] = RiemannSum(func, k, T);
        actualR(k) = I - S(k);
        theorR(k) = T^2 / k^2 / 24 * (df_b - df_a);
        RungeR(k) = S(k) - RiemannSum(func, 2 * k, T);
    end
    
    f = figure;
    title('Riemann Sum');
    hold on;
    grid on;
    actualPlot = semilogy(xs, actualR, 'DisplayName', 'Actual errors');
    theorPlot = semilogy(xs, theorR, 'DisplayName', 'Theoretical errors');
    RungePlot = semilogy(xs, RungeR, 'DisplayName', 'Runge');
    RPlot = semilogy(xs, R, 'DisplayName', 'periodic error');
    set(actualPlot, 'LineWidth', 1.5);
    set(theorPlot, 'LineWidth', 1.5);
    set(RungePlot, 'LineWidth', 1.5);
    set(RPlot, 'LineWidth', 1.5);
    legend('show');
    print(f, '-dpng', '-r300', 'RiemannSum');
end

