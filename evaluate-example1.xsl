<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xs="http://www.w3.org/2001/XMLSchema"
	exclude-result-prefixes="#all"
	version="3.0">

  <xsl:param name="xpath" as="xs:string" select="'xs:dateTime(//header/creationdate)'"/>

  <xsl:param name="utc-creation" as="xs:dateTime">
    <xsl:evaluate context-item="/" xpath="$xpath"/>
  </xsl:param>

  <xsl:mode on-no-match="shallow-copy"/>

  <xsl:template match="/" expand-text="yes">
    <xsl:copy>
      <xsl:apply-templates/>
      <xsl:comment>dateTime: {$utc-creation}</xsl:comment>
    </xsl:copy>
  </xsl:template>

</xsl:stylesheet>