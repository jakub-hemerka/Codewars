package com.mycompany.histogram;

public class Dinglemouse {
    public static String histogram(final int results[]) {
        String table[][] = BuildTable(results);
        StringBuilder builder = new StringBuilder();
        
        for (int i = table[0].length - 1; i >= 0; i--) {
            String line = "";
            for (int j = 0; j < table.length; j++) {
                line += table[j][i];
            }
            
            if (line.trim().length() > 0) {
                builder.append(line.replaceAll("\\s*$", ""));
                builder.append(System.getProperty("line.separator"));
            }
        }
        
    return builder.toString();
  }
    
    private static String[][] BuildTable(final int values[]) {
        int maximumBars = 15;
        int totalRolls = 0;
        char bar = '\u2588';
        
        for (int i = 0; i < values.length; i++) {
            totalRolls += values[i];
        }
        
        String output[][] = new String[values.length][maximumBars + 3];
        
        for (int i = 0; i < output.length; i++) {
            output[i][0] = " " + (i + 1) + " ";
            output[i][1] = "---";
            int percentage = (int)Math.floor((100f * values[i]) / totalRolls);
            int numberOfBars = (int)Math.floor((maximumBars * values[i]) / (float)totalRolls);
            
            for (int j = 2; j < output[i].length; j++) {
                if (j <= numberOfBars + 1) {
                    output[i][j] = String.format("%c%c ",bar, bar);
                } else {
                    output[i][j] = "   ";
                }
            }
            
            if (values[i] > 0) {
                if (percentage < 1f) {
                    output[i][numberOfBars + 2] = "<1%";
                } else {
                    output[i][numberOfBars + 2] = String.format("%-3s", percentage + "%");
                }
            }
        }
        
        return output;
    }
}
