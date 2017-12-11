function [ ys ] = f( xs )
    for i = 1 : length(xs)
        ys(i) = 1 / sqrt(1 + xs(i));
    end
end