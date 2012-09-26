function [vector] = vectCalc(Mat)
%   Esta funci�n calcula los vectores de prioridades para matrices
%   de criterios y alternativas

[autovectores, autovalores] = eig(Mat);

valores = max(autovalores);
[autovalor, posicion] = max(valores);
autovector = autovectores (:, posicion);
suma = sum(autovector);
autovector = (autovector / suma);
vector = autovector;

end