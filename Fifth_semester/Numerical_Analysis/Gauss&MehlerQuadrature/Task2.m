% draws graph of errors for Mehler quadrature
function [ ] = Task2( func )
    n = 10;
    xs = 1 : 1 : n;
    a = -1;
    b = 1;
    format long;
    I = vpa(int(func / sym('sqrt(1 - x^2)'), sym('x'), a, b), 15);
    
    for k = 1 : n
        % search of max difference in [a, b]
        maxDiff(k) = inf;
        df = diff(func, sym('x'), 2 * k);
        x = a + 0.5 ;
        maxDiff(k) = eval(df);
%         for i = 0 : 2 * n
%             x = a + i * 0.1;
%             temp = eval(df);
%             if (temp < maxDiff(k))
%                 maxDiff(k) = temp;
%             end
%         end
        
        maxError(k) = pi * maxDiff(k) / factorial(2 * k) / (2^(2 * k - 1));
        Sums(k) = MehlerQuadrature(func, k);
        actualErrors(k) = I - Sums(k);
    end
    
    actualErrors = double(actualErrors);
    
    f = figure;
    title('Mehler Quadrature');
    hold on;
    grid on;
    actErrPlot = semilogy(xs, actualErrors, 'DisplayName', 'Actual errors');
    theorErrPlot = semilogy(xs, maxError,...
                            'DisplayName', 'Theoretical errors');
    set(actErrPlot, 'LineWidth', 1.5);
    set(theorErrPlot, 'LineWidth', 1.5);
    legend('show');
    %print(f, '-dpng', '-r300', 'Mehler2');
end