
function gevalue (energy)
	if energy <= 0.11 then	
		return -16772 * energy^5 + 7316.5 * energy^4 - 1268.6 * energy^3 + 109.49 * energy^2 - 4.7059 * energy + 0.0822
	else	
		return 0.0013 * energy^6 - 0.0142 * energy^5 + 0.0629 * energy^4 - 0.138 * energy^3 + 0.1441 * energy^2 - 0.0197 * energy + 0.0028
	end
end