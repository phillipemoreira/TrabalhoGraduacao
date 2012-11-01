package br.com.tg.app5w2hplusplus.helper;

import java.io.InputStream;

import br.com.tg.app5w2hplusplus.exception.WSException;
import br.com.tg.app5w2hplusplus.exception.WSException.WSExceptionsType;

import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.ObjectMapper;

public class JsonHelper {

	public static <ObjectClass> ObjectClass deserializeJson(
			InputStream inputStream, Class<? extends ObjectClass> valueType)
			throws WSException {
		final ObjectMapper objectMapper = new ObjectMapper();
		// We indicate to the parser not to fail in case of unknown properties,
		// for backward compatibility reasons
		// See
		// http://stackoverflow.com/questions/6300311/java-jackson-org-codehaus-jackson-map-exc-unrecognizedpropertyexception
		objectMapper.configure(
				DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
		try {
			final ObjectClass businessObject = objectMapper.readValue(
					inputStream, valueType);
			return businessObject;
		} catch (Exception exception) {
			throw new WSException(exception.getMessage(),
					WSExceptionsType.PARSE_ERROR);
		}
	}
}
