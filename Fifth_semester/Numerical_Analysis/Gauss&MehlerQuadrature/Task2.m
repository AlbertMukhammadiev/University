% draws graph of errors for Mehler quadrature
function [ ] = Task2( func )
    n = 10;
    xs = 1 : 1 : n;
    a = -1;
    b = 1;
    syms x;
    I = vpa(int(func / sym('sqrt(1 - x^2)'), x, a, b), 15);
    
    % search of max difference in [a, b]
    maxDiff = -inf;
    df = diff(func, x, 2 * n);
    for i = 0 : 20
        x = a + i * 0.01;
        temp = eval(df);
        if (temp > maxDiff)
            maxDiff = temp;
        end
    end
    
    maxError = pi / factorial(2 * n) / 2^(2 * n - 1) * maxDiff;
    for k = 1 : n
        Sums(k) = MehlerQuadrature(func, k);
        actualErrors(k) = I - Sums(k);
    end
    
    actualErrors = double(actualErrors);
    
    f = figure;
    title('Mehler Quadrature');
    hold on;
    grid on;
    actErrPlot = semilogy(xs, actualErrors, 'DisplayName', 'Actual errors');
    %theorErrPlot = semilogy(xs, ones(size(xs)) * maxError,...
     %                       'DisplayName', 'Theoretical errors');
    set(actErrPlot, 'LineWidth', 1.5);
    %set(theorErrPlot, 'LineWidth', 1.5);
    legend('show');
    print(f, '-dpng', '-r300', 'Mehler2');
end