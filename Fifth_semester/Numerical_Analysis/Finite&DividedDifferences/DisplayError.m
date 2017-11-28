function [ output_args ] = DisplayError( )
x0 = 0.5;
df = 1.058421499379;
for i = 1 : 8
    epsilon(i) = 1 / 10^( 9 - i)
    x = [x0 (x0 + epsilon(i)) (x0 - epsilon(i)) (x0 + epsilon(i) * 2) (x0 - epsilon(i) * 2)];
    y = f(x);
    div_difference = DividedDifferences(x, y, length(x));
    error(i) = div_difference(1, length(x)) - df;
end
semilogx(epsilon, error);
end

