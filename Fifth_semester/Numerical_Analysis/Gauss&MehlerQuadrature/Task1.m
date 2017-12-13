% draws table for Gauss Legendre quadrature
function [ ] = Task1( func )
    a = 0;
    b = 0.4;
    n = 5;
    
    syms x;
    I = double(vpa(int(func, x, a, b), 15));
    
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
    
    error = double((b - a)^(2 * i + 1) * (factorial(i))^4 /...
            (2 * i + 1) / (fix(factorial(2 * n)))^3 * maxDiff);
    
    for i = 1 : n    
        S = GaussLegendreQuadrature(func, a, b, i);
        actualError = I - S;
        integrals(i) = I;
        Sums(i) = S;
        actualErrors(i) = actualError;
        theoreticalErrors(i) = error;
    end
    
    integrals = num2cell(integrals);
    Sums = num2cell(Sums);
    actualErrors = num2cell(actualErrors);
    theoreticalErrors = num2cell(theoreticalErrors);
    data = [integrals; Sums; actualErrors; theoreticalErrors];

    rowNames = {'exact value', 'approximation', 'actual error',...
                'theoretical error'};
    columnNames = {'n = 1', 'n = 2', 'n = 3', 'n = 4', 'n = 5'};
    f = figure('Position', [500 500 570 100]);
    t = uitable( f, 'Data', data, 'ColumnName',columnNames,...
                'RowName',rowNames,'Position', [0 0 565 95]);
    print(f, '-dpng', '-r300', 'table_GaussLegendre');

end

