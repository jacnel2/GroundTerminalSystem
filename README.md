## - Communication protocol between GT and ATS

  # 1. The Ground terminal will abort the connection forever when ATS sends the incorrect data. 

  >  At the end of the day, a data stream requires both the client and server to be in constant communication with each other.  If one were to be interrupted, you'd want to close the stream because you don't know if A, the client just decided to leave or B, the client didn't want to leave but had an issue. Leaving streams and ports open is a bad idea

  # 2. If the ATS's connection aborted due to the first protocol, the connection with that ATS won't be established until the GT restart.

  # 3. The ATS only validates whether the telemetry line has eight elements and the line can create checksum.

  > Our team don't want to waste the resource at both side of the program to validate the same content. So we divide each program's role to validate the telemetry line

  # 4. The connection will be established in TCP network stream with the IP address and Port number.

  # 5. Ideally, more than one ATS can connect to the GT at the same time.

***