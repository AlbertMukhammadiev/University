% draws table for Gauss Legendre quadrature
function [ ] = Task1( func )
    a = 0;
    b = 0.4;
    n0 = 4;
    n = 13;
    xs = n0 : 1 : n;
    
    syms x;
    I = double(vpa(int(func, sym('x'), a, b), 15));

    for i = n0 : n
        j = i - 3;
        S = GaussLegendreQuadrature(func, a, b, i);
        integrals(j) = I;
        Sums(j) = S;
        actualErrors(j) = I - S;
        
        % search of max difference in [a, b]
        maxDiff = -inf;
        df = diff(func, sym('x'), 2 * j);
        x = a + 0.1 ;
        maxDiff = eval(df);
%         for j = 0 : 20
%             x = a + i * 0.01;
%             temp = eval(df);
%             if (temp > maxDiff)
%                 maxDiff = temp;
%             end
%         end
    
        error(j) = double((b - a)^(2 * j + 1) * (factorial(j))^4 /...
                (2 * j + 1) / (fix(factorial(2 * j)))^3 * maxDiff);
        theoreticalErrors(j) = error(j);
    end
%     
%     integrals = num2cell(integrals);
%     Sums = num2cell(Sums);
%     actualErrors = num2cell(actualErrors);
%     theoreticalErrors = num2cell(theoreticalErrors);
%     data = [integrals; Sums; actualErrors; theoreticalErrors];
% 
%     rowNames = {'exact value', 'approximation', 'actual error',...
%                 'theoretical error'};
%     columnNames = {'n = 1', 'n = 2', 'n = 3', 'n = 4', 'n = 5'};
%     f = figure('Position', [500 500 570 100]);
%     t = uitable( f, 'Data', data, 'ColumnName',columnNames,...
%                 'RowName',rowNames,'Position', [0 0 565 95]);
%     print(f, '-dpng', '-r300', 'table_GaussLegendre');
    f = figure;
    title('Gauss-Legendre Quadrature');
    hold on;
    grid on;
    actErrPlot = semilogy(xs, actualErrors, 'DisplayName', 'Actual errors');
    theorErrPlot = semilogy(xs, theoreticalErrors,...
                            'DisplayName', 'Theoretical errors');
    set(actErrPlot, 'LineWidth', 1.5);
    set(theorErrPlot, 'LineWidth', 1.5);
    legend('show');
    
end

