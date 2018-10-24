rawData = LOAD 'input1.csv' using PigStorage(',') AS (ReportingFileNumber:int,CIK:int, NameofRegistrant:chararray, SeriesID:chararray, SeriesName:chararray, ClassID:chararray,
 ClassName:chararray, AddressA:chararray, City:chararray, State:chararray, ZipCode:int);

limitData = LIMIT rawData 2000;

processedData = foreach limitData generate ReportingFileNumber,CIK, NameofRegistrant, SeriesID, SeriesName, ClassID,
 ClassName,  AddressA, City, State, ZipCode;

Store processedData into './finaloutput' using PigStorage(',');

