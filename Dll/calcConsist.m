function [flag] = calcConsist(Mat)
%   Cálculo de consistencia según el criterio de Saaty
%   Esta función recibe una matriz AHP y determina si es consistente o no

RI = [0 0 0.58 0.9 1.12 1.24 1.32 1.41 1.45];

[filas, columnas] = size(Mat);
dimension = filas;

[autovectores, autovalores] = eig(Mat);

valores = max(autovalores);
[autovalor, posicion] = max(valores);
autovector = autovectores (:, posicion);
suma = sum(autovector);
autovector = (autovector / suma);

CI = (autovalor - dimension) / (dimension - 1);
CR = CI / RI(dimension);

if (CR <= 0.1)
    flag = true;
else
    flag = false;
end